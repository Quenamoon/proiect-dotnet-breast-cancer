import "./MainContent.css";
import "./MainContentTable.css";

const MainContent = () => {
  return (
    <div className="content">
      {/* <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tr-btn1-1").hide();
            $("#tr-btn1-2").hide();
            $("#tr-btn1-3").hide();
            $("#tr-btn2-1").hide();
            $("#tr-btn2-2").hide();
            $("#tr-btn2-3").hide();
            $("#btn1").click(function () {
                $('.buttonInactive').not(this).removeClass('buttonInactive');
                $(this).toggleClass('buttonActive');
                if ($(this).hasClass("buttonActive")) {
                    $("#tr-btn1-1").show();
                    $("#tr-btn1-2").show();
                    $("#tr-btn1-3").show();
                }
                else {
                  $("#tr-btn1-1").hide();
                  $("#tr-btn1-2").hide();
                  $("#tr-btn1-3").hide();
                }
            });
            $("#btn2").click(function () {
                $('.buttonInactive').not(this).removeClass('buttonInactive');
                $(this).toggleClass('buttonActive');
                if ($(this).hasClass("buttonActive")) {
                    $("#tr-btn2-1").show();
                    $("#tr-btn2-2").show();
                    $("#tr-btn2-3").show();
                }
                else {
                    $("#tr-btn2-1").hide();
                    $("#tr-btn2-2").hide();
                    $("#tr-btn2-3").hide();
                }
            });
        });
        
    </script> */}
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
                  <td>01-01-2020</td>
                  <td>Pozitiv</td>
                  <td>
                    <button
                      id="btn1"
                      type="button"
                      className="expand-button buttonInactive"
                    >
                      Expand details
                    </button>
                  </td>
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
                <tr>
                  <td>1</td>
                  <td>Maria</td>
                  <td>Anders</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>Francisco</td>
                  <td>Chang</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>3</td>
                  <td>Roland</td>
                  <td>Mendel</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Helen</td>
                  <td>Bennett</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>5</td>
                  <td>Yoshi</td>
                  <td>Tannamuri</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
                </tr>
                <tr>
                  <td>6</td>
                  <td>Giovanni</td>
                  <td>Rovelli</td>
                  <td>
                    <button className="pacient-button">Show prediction</button>
                  </td>
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
