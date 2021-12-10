import React from "react";
import { useSelector } from "react-redux";
import PredictionForm from "../Components/PredictionForm";
import { Navigate } from "react-router";
import { useState } from "react";
import "./Auth.css";

const Prediction = () => {
  const isAuthenticated = useSelector((state) => state.auth.isAuthenticated);
  const userType = useSelector((state) => state.auth.userType);
  const [error, setError] = useState("");
  const [successMessage, setSuccessMessage] = useState("");

  const predictionHandler = async (features) => {
    const data = {
      email: features.userEmail,
      password: features.userPassword,
      firstName: features.userFirstName,
      lastName: features.userLastName,
      userType: userType === "admin" ? "medic" : "patient",
    };
    try {
      const response = await fetch("https://localhost:5001/api/prediction", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json",
        },
        body: JSON.stringify(data),
      });
      if (response.status === 200) {
        const res = await response.json();
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <React.Fragment>
      <div className="wrapper" id="prediction-wrap">
        <PredictionForm
          registerHandler={predictionHandler}
          error={error}
          success={successMessage}
        />
      </div>
    </React.Fragment>
  );
};

export default Prediction;
