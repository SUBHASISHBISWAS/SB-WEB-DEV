import React from "react";
import PropTypes from "prop-types";
import Button from "./Button";

const Header = ({ title }) => {
  const onClick = () => {
    console.log("Click");
  };
  return (
    <header className="header">
      <h1>{title}</h1>
      <Button color="green" text="Add" onClick={onClick} />
    </header>
  );
};

Header.protoTypes = {
  title: PropTypes.string.isRequired,
};

const headingStyle = {
  color: "green",
  backgroundColor: "black",
};
export default Header;
