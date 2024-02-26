"use client";

import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { date, z } from "zod";

import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { PasswordInput } from "@/components/ui/input-password";
import { ToastAction } from "@/components/ui/toast";
import { useToast } from "@/components/ui/use-toast";
import { useRouter } from "next/navigation";
import { LoginCredential } from "@/types/app";
import { authenticate } from "@/lib/actions/authenticate";

const formSchema = z.object({
  email: z
    .string()
    .min(1, { message: "This field has to be filled." })
    .email("This is not a valid email."),
  password: z.string().min(4, { message: "Invalid password." }),
});

export function LoginForm() {
  const { toast } = useToast();
  const router = useRouter();

  // 1. Define form.
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      password: "",
    },
    mode: "onChange",
  });

  // 2. Define a submit handler.
  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      const loginCredential: LoginCredential = {
        email: values.email,
        password: values.password,
      };

      var data = await authenticate(loginCredential);

      toast({
        variant: "success",
        description: "Hello " + data.token.accessToken,
      });

      //router.push(`/tenants/${data.tenantid}`);
    } catch (error) {
      // Handle network errors and other exceptions
      toast({
        variant: "destructive",
        description: (error as Error).message || "Something went wrong!",
      });
    }
  }
  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input type="email" placeholder="Email" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="password"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Password</FormLabel>
              <FormControl>
                <PasswordInput placeholder="Password" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit" className="w-full">
          Login
        </Button>
      </form>
    </Form>
  );
}
