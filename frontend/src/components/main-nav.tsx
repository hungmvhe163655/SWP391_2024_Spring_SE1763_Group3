"use client";

import { useState } from "react";
import Link from "next/link";
import { Menu } from "lucide-react";
import { useAuth } from "@/lib/hooks/useAuth";
import NavAvatar from "./main-nav-avatar";

interface MenuItem {
  title: string;
  path: string;
}

const menus: MenuItem[] = [
  { title: "Sign In", path: "/login" },
  { title: "Sign Up", path: "/register" },
];

const MainNavbar: React.FC = () => {
  const [isMenuOpen, setMenuOpen] = useState(false);
  const auth = useAuth();

  const toggleMenu = () => {
    setMenuOpen(!isMenuOpen);
  };

  return (
    <nav className="w-full border-b md:border-0">
      <div className="items-center px-4 max-w-screen-xl mx-auto md:flex md:px-8">
        <div className="flex items-center justify-between py-3 md:py-5 md:block">
          <Link href="/">
            <h1 className="text-3xl font-bold text-gray-700">Logo</h1>
          </Link>
          <div className="md:hidden">
            <button
              className="text-gray-700 outline-none p-2 rounded-md focus:border-gray-400 focus:border"
              onClick={toggleMenu}
            >
              <Menu />
            </button>
          </div>
        </div>
        <div
          className={`flex-1 justify-self-center pb-3 mt-8 md:block md:pb-0 md:mt-0 ${isMenuOpen ? "block" : "hidden"}`}
        >
          <ul className="justify-end items-center space-y-8 md:flex md:space-x-6 md:space-y-0">
            {auth ? (
              <NavAvatar />
            ) : (
              menus.map((item, idx) => (
                <li key={idx} className="text-gray-500 hover:text-gray-900">
                  <Link href={item.path}>{item.title}</Link>
                </li>
              ))
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default MainNavbar;
