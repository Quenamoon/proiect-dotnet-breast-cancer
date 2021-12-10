import "./MainContent.css";
import "./MainContentTable.css";
import { useCallback, useEffect, useState } from "react";
import { useSelector } from "react-redux";

const MainContent = () => {
  let [patientsList, setPatientsList] = useState([]);
  let [patientsCounter, setPatientsCounter] = useState(0);
  let currentDoctorToken = useSelector((state) => state.auth.JWToken);

  const fetchPatients = useCallback(async () => {
    try {
      const response = await fetch(
        "https://localhost:5001/api/users/patients",
        {
          headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
            Authorization: "Bearer " + currentDoctorToken,
          },
        }
      );
      if (!response.ok) {
        throw new Error("Patients Get Request Went Wrong");
      }
      const data = await response.json();
      // [{email: "test", id: "5"}, {email: "test2", id: "2"}]
      setPatientsList((prevState) => [...prevState, ...data]);
    } catch (error) {
      console.log(error);
    }
  }, []);

  useEffect(() => {
    fetchPatients();
  }, [fetchPatients]);
  //##################################################33

  // useEffect(() => {
  //   let mounted = true;
  //   fetch(
  //     "https://localhost:5001/api/users/patients",
  //     {
  //       headers: {
  //         "Content-Type": "application/json",
  //         "Accept": "application/json",
  //         "Authorization": "Bearer " + currentDoctorToken,
  //       },
  //     }
  //   ).then(data => data.json())
  //   .then(items => {
  //       if(mounted) {
  //         setPatientsList(items)
  //       }
  //     })
  //   return () => mounted = false;
  // }, [])

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
                  <td>02-02-2021</td>
                  <td>Negativ</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
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
                <tr>
                  <td>01-02-2021</td>
                  <td>Negativ</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>05-02-2021</td>
                  <td>Pozitiv</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>03-02-2021</td>
                  <td>Negativ</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>02-02-2021</td>
                  <td>Pozitiv</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
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
                <tr>
                  <td>02-02-2021</td>
                  <td>Negativ</td>
                  <td>
                    <button id="btn2" type="button" className="expand-button">
                      Expand details
                    </button>
                  </td>
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
                  {/* <th>See prediction details</th> */}
                </tr>
              </thead>
              <tbody>
                {/* {patientsList.map((patient) => {
                  console.log(patientsList);
                  console.log(patientsCounter);
                  console.log(patientsList.length);
                  setPatientsCounter((prev) => {
                    return prev + 1;
                  });
                  console.log(patient);
                  return (
                    <tr key={patient.id}>
                      <td>{patientsCounter}</td>
                      <td>{patient.email}</td>
                      <td>
                        <button className="pacient-button">
                          Show prediction
                        </button>
                      </td>
                    </tr>
                  );
                })} */}

                <tr>
                  <td>1</td>
                  <td>Maria</td>
                  <td>Anders</td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>Francisca</td>
                  <td>Chang</td>
                </tr>
                <tr>
                  <td>3</td>
                  <td>Rolanda</td>
                  <td>Mendel</td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helena</td>
                  <td>Bennett</td>
                </tr>
                <tr>
                  <td>5</td>
                  <td>Yoshia</td>
                  <td>Tannamuri</td>
                </tr>
                <tr>
                  <td>6</td>
                  <td>Giovanna</td>
                  <td>Rovelli</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainContent;
