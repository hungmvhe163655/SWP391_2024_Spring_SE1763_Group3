
import { ColumnDef } from "@tanstack/react-table"
 
export type Profiles = {
  id: string
  FullName: string
  Gender: boolean
  PhoneNumber : string
  Email : string
  Adress : string
  BirthDate : Date
  Role : string
  status: "Active" | "Deleted"
}
export const columns: ColumnDef<Profiles>[] = [
    {
        accessorKey: "id",
        header: "ID",
    },
    {
        accessorKey: "FullName",
        header: "Full Name",
    },
    {
        accessorKey: "Gender",
        header: "Gender",
    },
    {
        accessorKey: "PhoneNumber",
        header: "Phone Number",
    },
    {
        accessorKey: "Email",
        header: "Email",
    },
    {
        accessorKey: "Adress",
        header: "Address",
    },
    {
        accessorKey: "BirthDate",
        header: "Birth Date",
    },
    {
        accessorKey: "Role",
        header: "Role",
    },
    {
        accessorKey: "status",
        header: "Status",
    },
];