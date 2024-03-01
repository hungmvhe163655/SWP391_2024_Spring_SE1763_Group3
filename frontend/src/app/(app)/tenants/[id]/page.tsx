import * as React from "react";
import DetailCard from "./DetailCard";

export default function Page({ params }: { params: { id: string } }) {
  return (
    <div>
      <DetailCard userId={params.id} />
    </div>
  );
}
