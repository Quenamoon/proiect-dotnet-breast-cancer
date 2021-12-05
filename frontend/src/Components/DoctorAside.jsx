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
          src="https://png.pngtree.com/png-vector/20190704/ourlarge/pngtree-businessman-user-avatar-free-vector-png-image_1538405.jpg"
          alt="profileimage"
        />
        <h4>Change Picture Picture</h4>
      </center>
      <button className="link_button">Detalii Profil</button>
      <button className="link_button">Pagina Principala</button>
    </div>
  );
};
export default DoctorAside;
