"use sever";

import { JwtCredential, LoginCredential } from "@/types/app";
import { fetchData } from "../utils/api";
import { AUTHORIZATION_API } from "../constants";

export const authenticate = async ({
  email,
  password,
}: LoginCredential): Promise<JwtCredential> => {
  try {
    const jwtCredential: JwtCredential = await fetchData({
      api: AUTHORIZATION_API + "/login",
      object: { email, password },
      method: "POST",
    });

    return jwtCredential;
  } catch (error) {
    throw error;
  }
};
