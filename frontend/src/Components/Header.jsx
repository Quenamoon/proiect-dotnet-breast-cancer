import React from "react";
import "./Header.css";
import { Navigate } from "react-router-dom";

const Header = () => {
  return (
    <header>
      <div className="left_area">
        <h3>
          Breast Cancer <span>Prediction</span>
        </h3>
      </div>
      <div className="right_area">
        <button className="logout_btn">Logout</button>
      </div>
    </header>
  );
};

export default Header;
