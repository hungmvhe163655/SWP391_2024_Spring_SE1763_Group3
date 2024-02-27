import MainFooter from "@/components/main-footer";
import MainNavbar from "@/components/main-nav";
import { Toaster } from "@/components/ui/toaster";
import { cn } from "@/lib/utils";

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <header>
        <MainNavbar />
      </header>
      {children}
      <MainFooter />
    </>
  );
}
