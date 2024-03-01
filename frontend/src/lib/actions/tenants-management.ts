"use server";

import { fetchData } from "../utils/api";
import { TENANTS_API } from "../constants";

export async function getTenants(userId: string) {
  const res = fetchData({
    api: TENANTS_API + "/" + userId,
  });
  return res;
}
