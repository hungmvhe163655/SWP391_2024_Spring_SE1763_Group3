"use client";

import { forwardRef } from "react";
import { Input, InputProps } from "@/components/ui/input";
import { cn } from "@/lib/utils";
import { Search } from "lucide-react";

const SearchInput = forwardRef<HTMLInputElement, InputProps>(
  ({ className, ...props }, ref) => {
    return (
      <div className="relative">
        <Search
          className="h-4 w-4 absolute top-1/2 transform -translate-y-1/2 left-2 text-gray-500"
          aria-hidden="true"
        />
        <Input
          type="text"
          className={cn("hide-password-toggle pr-10 pl-8", className)}
          placeholder="Search"
          {...props}
        />
      </div>
    );
  }
);
SearchInput.displayName = "SearchInput";

export { SearchInput as SearchInput };
