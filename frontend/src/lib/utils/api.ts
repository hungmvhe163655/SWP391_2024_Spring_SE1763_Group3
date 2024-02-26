import { FetchDataOptions } from "@/types/app";

export const fetchData = async <T, U>({
  api,
  object,
  method = "GET",
}: FetchDataOptions<T>): Promise<U> => {
  try {
    if (!api) {
      throw new Error("API not exist, try again later!");
    }

    const response = await fetch(api, {
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json;charset=UTF-8",
      },
      method: method,
      body: JSON.stringify(object),
    });

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(
        `Error: ${errorMessage}, Status Code: ${response.status}`
      );
    }

    return await response.json();
  } catch (error) {
    throw error;
  }
};
