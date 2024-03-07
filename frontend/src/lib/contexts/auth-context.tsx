"use client";
import { LoginInfo, AuthContextType } from "@/types/app";
import React, { createContext, useEffect, useState } from "react";

interface Props {
  children: React.ReactNode;
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: Props): React.ReactNode => {
  const [loginInfo, setLoginInfo] = useState<LoginInfo | null>(null);

  const login = (loginInfo: LoginInfo) => {
    setLoginInfo(loginInfo);
    localStorage.setItem("loginInfo", JSON.stringify(loginInfo));
  };

  const logout = () => {
    setLoginInfo(null);
    localStorage.removeItem("loginInfo");
  };

  useEffect(() => {
    // Fetch initial login info from localStorage
    const storedLoginInfo = JSON.parse(
      localStorage.getItem("loginInfo") ?? "null"
    ) as LoginInfo;

    // Update state with the fetched login info
    if (storedLoginInfo) {
      setLoginInfo(storedLoginInfo);
    }
  }, []);

  return (
    <AuthContext.Provider value={{ loginInfo, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
