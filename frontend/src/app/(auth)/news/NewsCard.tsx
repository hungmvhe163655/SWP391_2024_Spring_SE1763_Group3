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
import { NewsForm } from "./NewsForm";
import Link from "next/link";

export default function NewsCard() {
  return (
    <Card className="w-[350px]">
      <CardHeader className={cn("text-center")}>
        <CardTitle className={cn("text-2xl")}>Login</CardTitle>
        <CardDescription>Login to your account now !</CardDescription>
      </CardHeader>
      <CardContent>
        <NewsForm />
      </CardContent>
      <CardFooter>
        <ul>
          <li className="text-red-500 hover:text-red-700">
            <Link href="#">Forget Password?</Link>
          </li>
          <li className="pt-1">
            <p>
              Don&apos;t have an account?&nbsp;
              <Link
                className="text-red-500 hover:text-red-700"
                href="/register"
              >
                Register now
              </Link>
            </p>
          </li>
        </ul>
      </CardFooter>
    </Card>
  );
}
