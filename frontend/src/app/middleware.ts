import { NextRequest, NextResponse } from "next/server";
import { verifyJwtToken } from "@/lib/utils/auth";
import { LoginInfo } from "@/types/app";

const AUTH_PAGES = ["/login"];

const isAuthPages = (url: string) =>
  AUTH_PAGES.some((page) => page.startsWith(url));

export async function middleware(request: NextRequest) {
  const { url, nextUrl } = request;
  const storedToken: LoginInfo | null = JSON.parse(
    localStorage.getItem("loginInfo") ?? "null"
  );
  const hasVerifiedToken =
    storedToken && (await verifyJwtToken(storedToken.token.accessToken));

  const isAuthPageRequested = isAuthPages(nextUrl.pathname);

  if (isAuthPageRequested) {
    if (!hasVerifiedToken) {
      const response = NextResponse.next();
      localStorage.removeItem("loginInfo");
      return response;
    }
    const response = NextResponse.redirect(new URL(`/`, url));
    return response;
  }

  if (!hasVerifiedToken) {
    const searchParams = new URLSearchParams(nextUrl.searchParams);
    searchParams.set("next", nextUrl.pathname);
    const response = NextResponse.redirect(new URL("/login"));
    localStorage.removeItem("loginInfo");
    return response;
  }

  return NextResponse.next();
}
