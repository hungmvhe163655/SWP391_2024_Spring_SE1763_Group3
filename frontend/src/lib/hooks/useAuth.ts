"use client";
import React from "react";
import { verifyJwtToken } from "@/lib/utils/auth";
import { LoginInfo } from "@/types/app";

export function useAuth() {
  const [auth, setAuth] = React.useState<any>(null);

  const getVerifiedtoken = async () => {
    const storedToken: LoginInfo | null = JSON.parse(
      localStorage.getItem("loginInfo") ?? "null"
    );
    if (storedToken === null) return null;

    const verifiedToken = await verifyJwtToken(storedToken.token.accessToken);
    setAuth(verifiedToken);
  };
  React.useEffect(() => {
    getVerifiedtoken();
  }, []);
  return auth;
}
