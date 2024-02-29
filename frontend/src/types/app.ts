export interface LoginCredential {
  email: string;
  password: string;
}

export interface FetchDataOptions<T> {
  api: string | undefined;
  object: T;
  method?: "GET" | "POST" | "PUT" | "DELETE";
}

export interface LoginInfo {
  userId: string;
  userRoles: string[];
  token: { accessToken: string; refreshToken: string };
}

export interface RegisterAccount {
  fullName: string;
  userName: string;
  password: string;
  isMale: boolean;
  email: string;
  phoneNumber: string;
  roles: string[];
  dob: Date;
  address: string;
}

export interface ResponseMessage {
  message: string;
}
