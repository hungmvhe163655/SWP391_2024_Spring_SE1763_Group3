import {
  BadgeDollarSign,
  Contact2,
  FileCheck,
  Flag,
  KanbanSquare,
  ShowerHead,
} from "lucide-react";
import Image from "next/image";

const features = [
  {
    icon: <KanbanSquare />,
    title: "Rent Collection and Management",
    desc: "Automate rent payments, send reminders, and track late fees.",
  },
  {
    icon: <Contact2 />,
    title: "Maintenance Requests",
    desc: "Submit and track maintenance requests, including photos and detailed descriptions of the issue.",
  },
  {
    icon: <BadgeDollarSign />,
    title: "Payments",
    desc: "Pay rent and other fees electronically.",
  },
  {
    icon: <FileCheck />,
    title: "Leases and Documents",
    desc: "Access and manage lease agreements and other important documents electronically.",
  },
  {
    icon: <Flag />,
    title: "Accounting and Reporting",
    desc: "Generate reports on income, expenses, and vacancies.",
  },
  {
    icon: <ShowerHead />,
    title: "Room Management",
    desc: "Manage room, track inquiries and applications from prospective tenants.",
  },
];

export default function Home() {
  return (
    <main className="flex flex-col items-center justify-between p-15 min-h-screen mt-14">
      <section className="m-auto max-w-screen-xl pb-1 px-4 items-center lg:flex md:px-8">
        <div className="space-y-4 flex-1 sm:text-center lg:text-left">
          <h1 className="text-gray-800 font-bold text-4xl xl:text-5xl">
            Manage Your Apartment
            <span className="text-indigo-600"> Faster and Easier</span>
          </h1>
          <p className="text-gray-500 max-w-xl leading-relaxed sm:mx-auto lg:ml-0">
            Offers a solution for efficient apartment management. With intuitive
            features and user-friendly interface, it simplifies the tasks
            involved in overseeing an apartment complex or rental property.
          </p>
        </div>
        <div className="flex-1 text-center mt-4 lg:mt-0 lg:ml-3">
          <Image
            src={"/main-page-picture.jpg"}
            alt="Image description"
            width={1280}
            height={720}
            layout="responsive"
          />
        </div>
      </section>
      <section className="py-10">
        <div className="max-w-screen-xl mx-auto px-4 text-center text-gray-600 md:px-8">
          <div className="mt-5">
            <ul className="grid gap-y-8 gap-x-12 sm:grid-cols-2 lg:grid-cols-3">
              {features.map((item, idx) => (
                <li key={idx} className="space-y-3">
                  <div className="w-12 h-12 mx-auto bg-indigo-50 text-indigo-600 rounded-full flex items-center justify-center">
                    {item.icon}
                  </div>
                  <h4 className="text-lg text-gray-800 font-semibold">
                    {item.title}
                  </h4>
                  <p>{item.desc}</p>
                </li>
              ))}
            </ul>
          </div>
        </div>
      </section>
    </main>
  );
}
