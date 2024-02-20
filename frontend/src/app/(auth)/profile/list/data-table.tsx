"use client"
 
import {
  ColumnDef,
  getCoreRowModel,
  useReactTable,
} from "@tanstack/react-table"

import {
  Table,
  TableHeader,
  TableBody,
  TableHead,
  TableRow,
  TableCell,
} from "@/components/ui/table";

interface DataTableProps<TData, TValue> {
    columns: ColumnDef<TData, TValue>[]
    data: TData[]
  }
   
  export function DataTable<TData, TValue>({
    columns,
    data,
  }: DataTableProps<TData, TValue>) {
    const table = useReactTable({
      data,
      columns,
      getCoreRowModel: getCoreRowModel(),
    })
    return (
        <div className="rounded-md border">
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>ID</TableHead>
                <TableHead>Full Name</TableHead>
                <TableHead>Gender</TableHead>
                <TableHead>Phone Number</TableHead>
                <TableHead>Email</TableHead>
                <TableHead>Address</TableHead>
                <TableHead>Birth Date</TableHead>
                <TableHead>Role</TableHead>
                <TableHead>Status</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {table.getRowModel().rows?.length ? (
                table.getRowModel().rows.map((row) => (
                  <TableRow
                    key={row.id}
                    data-state={row.getIsSelected() && "selected"}
                  >
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> {/* Birth Date */}
                    <TableCell>{}</TableCell> 
                    <TableCell>{}</TableCell> 
                  </TableRow>
                ))
              ) : (
                <TableRow>
                  <TableCell colSpan={9} className="h-24 text-center">
                    No results.
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          </Table>
        </div>
      );
}