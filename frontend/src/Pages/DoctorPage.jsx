import DoctorAside from "../Components/DoctorAside";
import Header from "../Components/Header";
import PredictionsList from "../Components/PredictionsList";
import PatientsList from "../Components/PatientsList";
import "./DoctorPage.css";
import { Fragment } from "react";
import MainContent from "../Components/MainContent";

const DoctorPage = () => {
  return (
    <Fragment>
      <Header />
      <DoctorAside />
      <MainContent className="content" />
    </Fragment>
  );
};

export default DoctorPage;
