import * as React from "react"
import { Profiles, columns } from "./columns"
import { DataTable } from "./data-table"

async function getData(): Promise<Profiles[]> {
  // Fetch data from your API here.
  return [
    {
            id: "1",
            DateTime: new Date("2024-05-02"),
            Title: "Đóng tiền điện nước tháng 12/2023",
            Description: "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng"
          
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

