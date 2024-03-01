export interface LoginCredential {
  email: string;
  password: string;
}

export interface FetchDataOptions {
  api: string | undefined;
  object?: object;
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

export interface AuthContextType {
  loginInfo: LoginInfo | null;
  login: (loginInfo: LoginInfo) => void;
  logout: () => void;
}
export interface News {
  id: string;
  title: string;
  description: string;
}

export interface Tenant {
  id: string;
  fullName: string;
  phoneNumber: string;
  isMale: boolean;
  email: string;
  createdAt: Date;
  updatedAt?: Date;
  deletedAt?: Date;
  portraitPictureUrl?: string;
  dob: Date;
  address?: string;
  roomId?: string;
}
