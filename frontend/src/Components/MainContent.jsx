import "./MainContent.css";
import "./MainContentTable.css";
import { useCallback, useEffect, useState } from "react";
import { useSelector } from "react-redux";

const MainContent = () => {
  let [patientsList, setPatientsList] = useState([]);
  let [patientsCounter, setPatientsCounter] = useState(0);
  let currentDoctorToken = useSelector((state) => state.auth.JWToken);

  let fetchPatients = useCallback(async () => {
    try {
      const response = await fetch(
        "https://localhost:5001/api/users/patients",
        {
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Bearer " + currentDoctorToken,
          }
        }
      );
      if (!response.ok) {
        throw new Error("Patients Get Request Went Wrong");
      }
      const data = await response.json();

      const transformedPatients = data.map((patient) =>{
        console.log("patient = " + patient);
        return {
          email: patient.email,
          id: patient.id
        };
      });
      // [{email: "test", id: "5"}, {email: "test2", id: "2"}]
      setPatientsList(transformedPatients);
    } catch (error) {
      console.log(error);
    }
  }, []);

  
  useEffect(() => {
    fetchPatients();
  }, [fetchPatients]);

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
                    setPatientsCounter((prev) => { return prev + 1}); 
                    
                    return (
                      <tr key={patient.id}>
                        <td>{patientsCounter}</td>
                        <td>{patient.email}</td>
                        <td>
                          <button className="pacient-button">Show prediction</button>
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
