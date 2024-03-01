import { getNews } from "@/lib/actions/news-management";
import { columns } from "./columns"
import { DataTable } from "./data-table"


export default async function DemoPage() {
  const news = await getNews();

  return (
    <div className="container mx-auto py-10">
      <DataTable columns={columns} data={news} />
    </div>
  )
}
