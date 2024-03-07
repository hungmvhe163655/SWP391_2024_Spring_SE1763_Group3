import React from 'react';

function TermsAndConditions() {
  return (
    <div className="w-full py-12">
      <div className="container px-4 md:px-6">
        <div className="mx-auto prose max-w-[900px]">
        <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Terms and Conditions
      </h1>

          <ol style={{ textAlign: 'left', paddingLeft: '20px' }}>
            <li><strong>Acceptance of Terms:</strong> By accessing or using the HomeSharing System, you agree to be bound by these Terms and Conditions.</li>
            <li><strong>Use of the System:</strong> The HomeSharing System is provided for the purpose of facilitating home sharing arrangements between users. You agree to use the system in accordance with its intended purpose and all applicable laws and regulations.</li>
            <li><strong>User Responsibilities:</strong> Users are responsible for the accuracy of the information provided in their listings and profiles. Users are also responsible for any interactions or agreements made with other users through the system.</li>
            <li><strong>Privacy:</strong> We respect your privacy and are committed to protecting your personal information. Our Privacy Policy outlines how we collect, use, and disclose your information when you use the HomeSharing System.</li>
            <li><strong>Intellectual Property:</strong> The HomeSharing System and its content, including but not limited to text, graphics, logos, and images, are the property of G3 Company. Users may not use, reproduce, or distribute any content from the system without prior written permission.</li>
            <li><strong>Limitation of Liability:</strong> G3 Company is not liable for any damages or losses arising from the use of the HomeSharing System, including but not limited to direct, indirect, incidental, or consequential damages.</li>
            <li><strong>Modification of Terms:</strong> G3 Company reserves the right to modify these Terms and Conditions at any time. Users will be notified of any changes, and continued use of the system after modifications constitutes acceptance of the revised terms.</li>
            <li><strong>Termination:</strong> G3 Company reserves the right to terminate or suspend access to the HomeSharing System at any time, without prior notice, for any reason, including but not limited to violation of these Terms and Conditions.</li>
            <li><strong>Governing Law:</strong> These Terms and Conditions are governed by the laws of VietNam. Any disputes arising out of or related to these terms shall be resolved exclusively by the courts of VietNam.</li>
          </ol>
        </div>
      </div>
    </div>
    
  );
}

export default TermsAndConditions;
