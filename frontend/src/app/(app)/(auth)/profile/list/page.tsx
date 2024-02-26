import * as React from "react"
import { Profiles, columns } from "./columns"
import { DataTable } from "./data-table"

async function getData(): Promise<Profiles[]> {
  // Fetch data from your API here.
  return [
    {
        
            id: "728ed52f",
            FullName: "John Doe",
            Gender: true,
            PhoneNumber: "123-456-7890",
            Email: "john@example.com",
            Adress: "123 Main St, City, Country",
            BirthDate: new Date("1990-01-01"),
            Role: "Admin",
            status: "Active"
          
    },
  ]
}

export default async function Profiles() {
    const data = await getData()

    return(
        <div className="container mx-auto py-10">
        <DataTable columns={columns} data={data} />
    </div>
    );
}

