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
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { CalendarIcon } from "lucide-react";
import { cn } from "@/lib/utils";
import { format } from "date-fns";
import { Calendar } from "@/components/ui/calendar";
import { useToast } from "@/components/ui/use-toast";
import { ToastAction } from "@/components/ui/toast";

const api = process.env.NEXT_PUBLIC_TENANT_API_URL;

const formSchema = z
  .object({
    fullname: z.string().min(1, { message: "Full name is required" }).max(255),
    email: z.string().min(1, { message: "Email is required" }).max(255).email(),
    gender: z.enum(["male", "female"], {
      required_error: "You need to select a gender.",
    }),
    dob: z.date({
      required_error: "A date of birth is required.",
    }),
    password: z
      .string()
      .min(8, { message: "Password must at least 4 characters" })
      .max(255, { message: "Password must at max 255 characters" }),
    confirmPassword: z.string(),
  })
  .refine((fields) => fields.password === fields.confirmPassword, {
    path: ["confirmPassword"],
    message: "Passwords don't match",
  });

export function RegisterForm() {
  const { toast } = useToast();

  // 1. Define form.
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      fullname: "",
      email: "",
      password: "",
      confirmPassword: "",
    },
  });

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

    var tenant = {
      fullname: values.fullname,
      password: values.password,
      email: values.email,
      dob: values.dob,
      isMale: values.gender === "male",
      roleId: 1,
      portraitPictureUrl: "",
      createdAt: new Date(),
      roomId: null,
    };
    console.log(JSON.stringify(tenant));

    try {
      const response = await fetch(api, {
        headers: {
          Accept: "application/json, text/plain",
          "Content-Type": "application/json;charset=UTF-8",
        },
        method: "POST",
        body: JSON.stringify(tenant),
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
      console.log(data);
    } catch (error) {
      // Handle network errors and other exceptions
      ErrorPopup((error as Error).message || "Something went wrong!");
    }
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
        {
          // Full Name Field
        }
        <FormField
          control={form.control}
          name="fullname"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Full Name</FormLabel>
              <FormControl>
                <Input type="fullname" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        {
          // Gender Field
        }
        <FormField
          control={form.control}
          name="gender"
          render={({ field }) => (
            <FormItem className="space-y-3">
              <FormLabel>Gender</FormLabel>
              <FormControl>
                <RadioGroup
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                  className="flex flex-col space-y-1"
                >
                  <FormItem className="flex items-center space-x-3 space-y-0">
                    <FormControl>
                      <RadioGroupItem value="male" />
                    </FormControl>
                    <FormLabel className="font-normal">Male</FormLabel>
                  </FormItem>
                  <FormItem className="flex items-center space-x-3 space-y-0">
                    <FormControl>
                      <RadioGroupItem value="female" />
                    </FormControl>
                    <FormLabel className="font-normal">Female</FormLabel>
                  </FormItem>
                </RadioGroup>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        {
          // Date of Birth Field
        }
        <FormField
          control={form.control}
          name="dob"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Date of birth</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <Button
                    variant={"outline"}
                    className={cn(
                      "w-[240px] justify-start text-left font-normal",
                      !field.value && "text-muted-foreground"
                    )}
                  >
                    <CalendarIcon className="mr-2 h-4 w-4" />
                    {field.value ? (
                      format(field.value, "PPP")
                    ) : (
                      <span>Pick a date</span>
                    )}
                  </Button>
                </PopoverTrigger>
                <PopoverContent align="start" className=" w-auto p-0">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    captionLayout="dropdown-buttons"
                    fromYear={1900}
                    toYear={new Date().getFullYear()}
                    onSelect={field.onChange}
                    disabled={(date: Date) =>
                      date > new Date() || date < new Date("1900-01-01")
                    }
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />
        {
          // Email Field
        }
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
        {
          // Password Field
        }
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
        {
          // Confirm Password Field
        }
        <FormField
          control={form.control}
          name="confirmPassword"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Confirm Password</FormLabel>
              <FormControl>
                <PasswordInput placeholder="Confirm Password" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit" className="w-full">
          Register
        </Button>
      </form>
    </Form>
  );
}
