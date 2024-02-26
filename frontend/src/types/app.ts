export interface LoginCredential {
  email: string;
  password: string;
}

export interface FetchDataOptions<T> {
  api: string | undefined;
  object: T;
  method?: "GET" | "POST" | "PUT" | "DELETE";
}

export interface JwtCredential {
  token: { accessToken: string; refreshToken: string };
}
