"use sever";

import { LoginCredential } from "@/types/app";
import { signIn } from "../utils/auth";

export const authenticate = async ({ email, password }: LoginCredential) => {
  try {
    var jwtCredential = await signIn({ email, password });
  } catch (error) {}
};
