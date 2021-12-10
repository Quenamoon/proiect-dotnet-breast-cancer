import "./MainContent.css";
import "./MainContentTable.css";
import { useEffect, useState, useRef } from "react";
import { useSelector } from "react-redux";

const MainContent = () => {
  let [patientsList, setPatientsList] = useState([]);
  let currentDoctorToken = useSelector((state) => state.auth.JWToken);
  let [selectedPatientId, setSelectedPatientId] = useState("");
  let [predictionList, setPredictionList] = useState([])
  const fetchPatients = async () => {
    try {
      const response = await fetch(
        "https://localhost:5001/api/users/patients",
        {
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": currentDoctorToken,
          }
        }
      );
      if (!response.ok) {
        throw new Error("Patients Get Request Went Wrong");
      }
      return response.json();
    } catch (error) {
      console.log(error);
    }
  }

  const fetchPatientPredictions = async (patientId) => {
    try {
      const response = await fetch(
        "https://localhost:5001/api/patients/" + patientId + "/predictions",
        {
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": currentDoctorToken,
          }
        }
      );
      if (!response.ok) {
        throw new Error("Patient Predictions Get Request Went Wrong");
      }
      return response.json();
    } catch (error) {
      console.log(error);
    }
  }

  useEffect(async () => {
    const patients = await fetchPatients()
    let counter = 1
    setPatientsList(patients.map((elem) => ({
      count: (counter++),
      id: elem.id,
      firstName: elem.firstName,
      lastName: elem.lastName
    })))
  }, []);

  const showPatientPredictionsHandler = async (patientId) => {
    const predictions = await fetchPatientPredictions(patientId)
    setPredictionList(
      predictions.map(prediction => ({
        id: prediction.id,
        date: prediction.predictionDate.substring(0, 10),
        diagnosis: prediction.diagnosis == "true" ? "pozitiv" : "negativ"
      })))
  }

  return (
    <div className="content">
      <div className="content-container">
        <div className="flex-child prediction">
          <button className="prediction-button" role="GenerateButton">
            Generate prediction
          </button>
          {
            predictionList !== [] ?
              <div className="table-container">
                <table className="table-structure">
                  <thead>
                    <tr>
                      <th>Prediction Date</th>
                      <th>Result</th>
                      <th>See more</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      predictionList.map((prediction) => {
                        return (
                          <tr key={prediction.id}>
                            <td>{prediction.date}</td>
                            <td>{prediction.diagnosis}</td>
                            <td>
                              <button id="btn2" type="button" className="expand-button">
                                Expand details
                              </button>
                            </td>
                          </tr>
                        );
                      })
                    }
                  </tbody>
                </table>
              </div>
              :
              <p>No patient selected.</p>
          }
        </div>

        <div className="flex-child patient-list">
          <div className="button-container">
            <button className="pacient-button" role="AddButton">
              Add a pacient
            </button>
            <button className="pacient-button" role="DeleteButton">
              Delete a pacient
            </button>
          </div>
          <div className="table-container">
            <table>
              <thead>
                <tr>
                  <th>Pacient ID</th>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>See prediction details</th>
                </tr>
              </thead>
              <tbody>
                {
                  patientsList.map((patient) => {
                    return (
                      <tr key={patient.id}>
                        <td>{patient.count}</td>
                        <td>{patient.firstName}</td>
                        <td>{patient.lastName}</td>
                        <td>
                          <button className="pacient-button" onClick={() => { showPatientPredictionsHandler(patient.id) }}>Show predictions</button>
                        </td>
                      </tr>
                    );
                  })
                }

              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainContent;
