import * as React from "react";

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import { cn } from "@/lib/utils";
import Link from "next/link";
import { RegisterForm } from "./RegisterForm";

export default function RegisterCard() {
  return (
    <Card className="w-[350px]">
      <CardHeader className={cn("text-center")}>
        <CardTitle className={cn("text-2xl")}>Register</CardTitle>
        <CardDescription>Register your account now !</CardDescription>
      </CardHeader>
      <CardContent>
        <RegisterForm />
      </CardContent>
      <CardFooter>
        <ul>
          <li className="text-red-500 hover:text-red-700">
            <Link href="#">Forget Password?</Link>
          </li>
          <li className="pt-1">
            <p>
              Already have an account?
              <Link className="text-red-500 hover:text-red-700" href="/login">
                Login
              </Link>
            </p>
          </li>
        </ul>
      </CardFooter>
    </Card>
  );
}
