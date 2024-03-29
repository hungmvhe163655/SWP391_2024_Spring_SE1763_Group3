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
import { useRouter } from "next/navigation";
import { RegisterAccount } from "@/types/app";
import { register } from "@/lib/actions/authenticate";
import PhoneInput from "react-phone-input-2";
import "react-phone-input-2/lib/style.css";

const formSchema = z
  .object({
    fullname: z.string().min(1, { message: "Full name is required" }).max(255),
    email: z.string().min(1, { message: "Email is required" }).max(255).email(),
    gender: z.enum(["male", "female"], {
      required_error: "You need to select a gender.",
    }),
    roles: z.enum(["tenant", "home manager"], {
      required_error: "You need to select a roles.",
    }),
    phoneNumber: z.string().min(3, { message: "Phone number is required" }),
    dob: z.date({
      required_error: "A date of birth is required.",
    }),
    password: z
      .string()
      .min(5, { message: "Password must at least 5 characters" })
      .max(255, { message: "Password must at max 255 characters" })
      .refine(
        (value) => {
          const regex = [];
          // Include password requirements
          regex.push(/(?=.*\d)/); // Require at least one digit
          regex.push(/(?=.*[a-z])/); // Require at least one lowercase letter
          regex.push(/(?=.*[A-Z])/); // Require at least one uppercase letter
          regex.push(/(?=.*\W|_)/); // Require at least one non-alphanumeric character

          // Check if the password meets all requirements
          const valid = regex.every((r) => r.test(value));
          return valid;
        },
        {
          message:
            "Password must contain at least one digit, one lowercase letter, one uppercase letter, and one non-alphanumeric character",
        }
      ),
    confirmPassword: z.string(),
  })
  .refine((fields) => fields.password === fields.confirmPassword, {
    path: ["confirmPassword"],
    message: "Password doesn't match",
  });

export function RegisterForm() {
  const { toast } = useToast();
  const router = useRouter();

  // 1. Define form.
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      fullname: "",
      email: "",
      password: "",
      confirmPassword: "",
      phoneNumber: "",
    },
  });

  // 2. Define a submit handler.
  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      var account: RegisterAccount = {
        fullName: values.fullname,
        password: values.password,
        email: values.email,
        userName: values.email,
        phoneNumber: values.phoneNumber,
        dob: values.dob,
        isMale: values.gender === "male",
        roles: [values.roles],
        address: "",
      };
      console.log(JSON.stringify(account));

      var data = await register(account);

      toast({
        variant: "success",
        description: data.message,
      });

      router.push("/login");
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
          // Roles Field
        }
        <FormField
          control={form.control}
          name="roles"
          render={({ field }) => (
            <FormItem className="space-y-3">
              <FormLabel>Roles</FormLabel>
              <FormControl>
                <RadioGroup
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                  className="flex flex-row space-x-2"
                >
                  <FormItem className="flex items-center space-x-3 space-y-0">
                    <FormControl>
                      <RadioGroupItem value="tenant" />
                    </FormControl>
                    <FormLabel className="font-normal">Tenant</FormLabel>
                  </FormItem>
                  <FormItem className="flex items-center space-x-3 space-y-0">
                    <FormControl>
                      <RadioGroupItem value="home manager" />
                    </FormControl>
                    <FormLabel className="font-normal">Home Manager</FormLabel>
                  </FormItem>
                </RadioGroup>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
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
          // Phone Number Field
        }
        <FormField
          control={form.control}
          name="phoneNumber"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Phone Number</FormLabel>
              <FormControl>
                <PhoneInput
                  {...field}
                  specialLabel=""
                  country={"vn"}
                  enableSearch={true}
                  countryCodeEditable={false}
                />
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
                  className="flex flex-row space-x-2"
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
