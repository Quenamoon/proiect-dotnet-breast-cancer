import React, { Fragment } from "react";
import "./DoctorAside.css";
import { Navigate } from "react-router-dom";

// const DoctorAside = () => {
//   return (
//     <div className="aside">
//       <div className="aside--profile-pic--img-holder">
//         <img
//           src="https://www.pngitem.com/pimgs/m/150-1503945_transparent-user-png-default-user-image-png-png.png"
//           alt="Profile Pic"
//           className="aside--profile-pic--img"
//         />
//       </div>
//       <input
//         type="file"
//         name="Change Profile Picture"
//         className="aside--profile-pic--img-choser"
//         accept="image/* "
//       />

//       <ul className="aside-links">
//         <li className="aside-links--link-item">
//           <a href="#">Detalii Profil</a>
//         </li>
//         <li className="aside-links--link-item">
//           <a href="#">Pagina Principala</a>
//         </li>
//       </ul>
//     </div>
//   );
// };

const DoctorAside = () => {
  return (
    <div className="aside">
      <center>
        <img
          className="profile_image"
          src="https://media.istockphoto.com/vectors/breast-cancer-awareness-with-realistic-pink-ribbon-on-a-white-women-vector-id1176663746?k=20&m=1176663746&s=612x612&w=0&h=6pZAa7Gl51p3TySMX0YgFkOIVgf2PX7LN9MExpYeMMc="
          alt="profileimage"
        />
        <h4>Stronger Together</h4>
      </center>
      <button className="link_button">Detalii Profil</button>
      <button className="link_button">Pagina Principala</button>
    </div>
  );
};
export default DoctorAside;
