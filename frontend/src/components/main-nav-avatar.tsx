"use client";

import Link from "next/link";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { useRouter } from "next/navigation";
import { useContext } from "react";
import { AuthContextType } from "@/types/app";
import AuthContext from "@/lib/contexts/auth-context";

interface MenuItem {
  title: string;
  path: string;
}

const avatarMenus: MenuItem[] = [
  { title: "Dashboard", path: "#" },
  { title: "Settings", path: "#" },
];

const NavAvatar: React.FC = () => {
  const router = useRouter();
  const { logout } = useContext(AuthContext) as AuthContextType;

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Avatar className="h-8 w-8 cursor-pointer">
          <AvatarImage src="/default-avatar.jpg" />
          <AvatarFallback>CN</AvatarFallback>
        </Avatar>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        {avatarMenus.map((item, idx) => (
          <DropdownMenuItem asChild key={idx}>
            <Link href={item.path}>{item.title}</Link>
          </DropdownMenuItem>
        ))}
        <DropdownMenuItem asChild>
          <p
            onClick={() => {
              logout();
              router.push("/login");
            }}
          >
            Log Out
          </p>
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default NavAvatar;
