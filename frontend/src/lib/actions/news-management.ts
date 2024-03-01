"use sever";


import { NEWS_API } from "../constants";
import { News } from "@/types/app";


export const getNews = async (): Promise<News[]> => {
  try {
    const res =  await fetch(NEWS_API!, {
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json;charset=UTF-8",
      },
      method: "GET"
    });


    const news: News[] = await res.json();
    return news;
  } catch (error) {
    throw error;
  }
};
