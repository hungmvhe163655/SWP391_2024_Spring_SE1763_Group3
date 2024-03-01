import MainFooter from "@/components/main-footer";
import MainNavbar from "@/components/main-nav";
import { Toaster } from "@/components/ui/toaster";
import { AuthProvider } from "@/lib/contexts/auth-context";
import { cn } from "@/lib/utils";

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <AuthProvider>
      <header>
        <MainNavbar />
      </header>
      {children}
      <MainFooter />
    </AuthProvider>
  );
}
