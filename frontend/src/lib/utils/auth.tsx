import { LoginCredential } from "@/types/app";
import { AUTHORIZATION_API } from "../constants";

export const signIn = async (loginCredential: LoginCredential) => {
  try {
    if (!AUTHORIZATION_API) {
      throw new Error("Something error, try again later!");
    }

    const response = await fetch(AUTHORIZATION_API, {
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json;charset=UTF-8",
      },
      method: "POST",
      body: JSON.stringify(loginCredential),
    });

    // Check if the response is successful
    if (!response.ok) {
      // Handle different error statuses
      if (response.status === 400) {
        throw new Error("Bad Request: Please check your input data.");
      }

      if (response.status === 401) {
        const errorMessage = await response.text(); // Extract error message from response
        throw new Error(`Unauthorized: ${errorMessage}`);
      }

      throw new Error("Server Error: Something went wrong on the server side.");
    }

    // Parse the response JSON
    return await response.json();
  } catch (error) {
    // Handle network errors and other exceptions
    throw error;
  }
};
