"use sever";

import {
  JwtCredential,
  LoginCredential,
  RegisterAccount,
  ResponseMessage,
} from "@/types/app";
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

export const register = async (
  registerAccount: RegisterAccount
): Promise<ResponseMessage> => {
  try {
    const responseMessage: ResponseMessage = await fetchData({
      api: AUTHORIZATION_API + "/register",
      object: registerAccount,
      method: "POST",
    });

    return responseMessage;
  } catch (error) {
    throw error;
  }
};
