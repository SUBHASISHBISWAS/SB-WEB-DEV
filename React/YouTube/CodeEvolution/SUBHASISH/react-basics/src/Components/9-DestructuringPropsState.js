import React from "react";

export const DestructuringProps = ({ name, title }) => {
  console.log(name, title);
  return (
    <div>
      <h1>
        Hello {name} a.k.a {title}
      </h1>
    </div>
  );
};
