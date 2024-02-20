"use client";

import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";

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

const api = process.env.NEXT_PUBLIC_TENANT_API_URL;

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
  function ErrorPopup(message: string) {
    toast({
      variant: "destructive",
      title: "Uh oh! Something went wrong.",
      description: message,
      action: <ToastAction altText="Try again">Try again</ToastAction>,
    });
  }

  // 2. Define a submit handler.
  async function onSubmit(values: z.infer<typeof formSchema>) {
    if (!api) {
      ErrorPopup("Something went wrong!");
      return;
    }

    try {
      const response = await fetch(api, {
        headers: {
          Accept: "application/json, text/plain",
          "Content-Type": "application/json;charset=UTF-8",
        },
        method: "POST",
        body: JSON.stringify(values),
      });

      // Check if the response is successful
      if (!response.ok) {
        // Handle different error statuses
        if (response.status === 400) {
          throw new Error("Bad Request: Please check your input data.");
        }

        throw new Error(
          "Server Error: Something went wrong on the server side."
        );
      }

      // Parse the response JSON
      const data = await response.json();
      toast({
        variant: "success",
        description: "Hello " + data.fullname,
      });
      router.push(`/tenants/${data.tenantid}`);
    } catch (error) {
      // Handle network errors and other exceptions
      ErrorPopup((error as Error).message || "Something went wrong!");
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
