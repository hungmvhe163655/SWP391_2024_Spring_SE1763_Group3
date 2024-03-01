import React from 'react';
function Aboutus() {
    return (
        <div className="relative isolate overflow-hidden bg-gray-900 py-24 sm:py-32">
  

  <div className="mx-auto max-w-7xl px-6 lg:px-8">
    <div className="mx-auto max-w-2xl lg:mx-0">
      <h2 className="text-4xl font-bold tracking-tight text-white sm:text-6xl">Welcome To Home Sharing System</h2>
      <p className="mt-6 text-lg leading-8 text-gray-300">HomeSharingSystem is a new utility system with many welcomes from users across Vietnam. Every day, Hosts offer unique stays and experiences that make it possible for guests to connect with communities in a more authentic way.</p>
    </div>
    <div className="mx-auto mt-10 max-w-2xl lg:mx-0 lg:max-w-none">
      <div className="grid grid-cols-1 gap-x-8 gap-y-6 text-base font-semibold leading-7 text-white sm:grid-cols-2 md:flex lg:gap-x-10">
        <a href="#">Connect With Us <span aria-hidden="true">&rarr;</span></a>
        <a href="#">Internship program <span aria-hidden="true">&rarr;</span></a>
        <a href="/termandconditions">Term And Conditions <span aria-hidden="true">&rarr;</span></a>
        <a href="#">Meet Our Leadership <span aria-hidden="true">&rarr;</span></a>
      </div>
      <dl className="mt-16 grid grid-cols-1 gap-8 sm:mt-20 sm:grid-cols-2 lg:grid-cols-4">
        <div className="flex flex-col-reverse">
          <dt className="text-base leading-7 text-gray-300">Hosts on Airbnb</dt>
          <dd className="text-2xl font-bold leading-9 tracking-tight text-white">50K</dd>
        </div>
        <div className="flex flex-col-reverse">
          <dt className="text-base leading-7 text-gray-300">Earned by Hosts, all-time</dt>
          <dd className="text-2xl font-bold leading-9 tracking-tight text-white">$5M+</dd>
        </div>
        <div className="flex flex-col-reverse">
          <dt className="text-base leading-7 text-gray-300">Airbnb guest arrivals all-time</dt>
          <dd className="text-2xl font-bold leading-9 tracking-tight text-white">2M+</dd>
        </div>
        <div className="flex flex-col-reverse">
          <dt className="text-base leading-7 text-gray-300">Total taxes collected and remitted </dt>
          <dd className="text-2xl font-bold leading-9 tracking-tight text-white">$30K</dd>
        </div>
      </dl>
    </div>
  </div>
</div>
        );
    }
    
    export default Aboutus;