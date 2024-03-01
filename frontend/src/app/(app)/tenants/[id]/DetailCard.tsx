import * as React from "react";

const DetailCard: React.FC<{ userId: string }> = ({ userId }) => {
  return <div>{userId}</div>;
};

export default DetailCard;
