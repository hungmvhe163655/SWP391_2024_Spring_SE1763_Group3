import * as React from "react";
import DetailCard from "./DetailCard";
import { getTenants } from "@/lib/actions/tenants-management";
import { Tenant } from "@/types/app";

export default async function Page({ params }: { params: { id: string } }) {
  var res = (await getTenants(params.id)) as Tenant;
  return (
    <div>
      <DetailCard tenant={res} />
    </div>
  );
}
