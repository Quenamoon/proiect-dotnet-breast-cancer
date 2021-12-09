import "./MainContent.css";
import "./MainContentTable.css";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";

const MainContent = () => {
  let [patientsList, setPatientsList] = useState([]);
  let currentDoctorToken = useSelector((state) => state.auth.JWToken);
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

  return (
    <div className="content">
      <div className="content-container">
        <div className="flex-child prediction">
          <button className="prediction-button" role="GenerateButton">
            Generate prediction
          </button>
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
                <tr>
                  <td>Smth 1</td>
                  <td>Smth 2</td>
                  <td>Smth 3</td>
                </tr>
                <tr>
                  <td>Smth 1</td>
                  <td>Smth 2</td>
                  <td>Smth 3</td>
                </tr>

                <tr>
                  <td>02-02-2021</td>
                  <td>Negativ</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
                </tr>
                <tr id="tr-btn2-1">
                  <td>Smth 1</td>
                  <td>Smth 2</td>
                  <td>Smth 3</td>
                </tr>
                <tr id="tr-btn2-2">
                  <td>Smth 1</td>
                  <td>Smth 2</td>
                  <td>Smth 3</td>
                </tr>
                <tr id="tr-btn2-3">
                  <td>Smth 1</td>
                  <td>Smth 2</td>
                  <td>Smth 3</td>
                </tr>
              </tbody>
            </table>
          </div>
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
                          <button className="pacient-button">Show predictions</button>
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
