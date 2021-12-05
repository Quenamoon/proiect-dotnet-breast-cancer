import DoctorAside from "../Components/DoctorAside";
import Header from "../Components/Header";
import PredictionsList from "../Components/PredictionsList";
import PatientsList from "../Components/PatientsList";
import "./DoctorPage.css";
import { Fragment } from "react";

const DoctorPage = () => {
  return (
    <Fragment>
      <Header />
      <DoctorAside />
      <div className="content">
        <h1>Test</h1>
      </div>
    </Fragment>
  );
};

export default DoctorPage;
