"use sever";

import { NEWS_API } from "../constants";
import { News } from "@/types/app";
process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

export const getNews = async (): Promise<News[]> => {
  try {
    const res = await fetch(NEWS_API!);

    const news: News[] = await res.json();
    return news;
  } catch (error) {
    throw error;
  }
};
