
"use client"

import { News } from "@/types/app";
import { ColumnDef } from "@tanstack/react-table"
 
export const columns: ColumnDef<News>[] = [
    {
        accessorKey: "id",
        header: "id",
    },
    {
        accessorKey: "title",
        header: "title",
    },
    {
        accessorKey: "description",
        header: "description",
    },
];