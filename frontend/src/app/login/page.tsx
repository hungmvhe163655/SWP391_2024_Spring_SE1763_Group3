import LoginCard from "./loginCard";

const Login = () => {
  return (
    <div className="flex flex-1 bg-slate-200 min-h-screen">
      <div className="w-2/3 grid-rows-2 gap-4 place-content-center">
        <div>He</div>
        <div>He</div>
      </div>
      <div className="w-1/3 m-auto">
        <LoginCard />
      </div>
    </div>
  );
};

export default Login;
