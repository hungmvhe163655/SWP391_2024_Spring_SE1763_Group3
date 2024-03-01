"use client";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Tenant } from "@/types/app";
import * as React from "react";

const DetailCard: React.FC<{ tenant: Tenant }> = ({ tenant }) => {
  return (
    <Card className="w-[350px]">
      <CardHeader>
        <CardTitle className="text-center">{tenant.fullName}</CardTitle>
      </CardHeader>
      <CardContent></CardContent>
      <CardFooter className="flex justify-between">
        <Button>Update Profile</Button>
      </CardFooter>
    </Card>
  );
};

export default DetailCard;
