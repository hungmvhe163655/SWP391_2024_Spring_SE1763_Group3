
import { ColumnDef } from "@tanstack/react-table"
 
export type Profiles = {
  id: string
  DateTime: Date
  Title: string
  Description : string
}
export const columns: ColumnDef<Profiles>[] = [

    {
        accessorKey: "DateTime",
        header: "Date Time",
    },
    {
        accessorKey: "Title",
        header: "Title",
    },
    {
        accessorKey: "Description",
        header: "Description",
    },
];