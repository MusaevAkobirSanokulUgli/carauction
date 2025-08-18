import EmptyFilter from "@/app/components/EmptyFilter";
import React from "react";

export default function page({
  searchParams
}: {
  searchParams: { callbackUrl?: string };
}) {
  return (
    <EmptyFilter
      title="You need to log in first"
      subtitle="Please log in to continue"
      showLogin
      callbackUrl={searchParams.callbackUrl}
    />
  );
}
