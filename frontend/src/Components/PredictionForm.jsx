import { useState } from "react";
import "./AuthForm.css";

const PredictionForm = (props) => {
  const [features, setFeatures] = useState({
    radius: "",
    texture: "",
    perimeter: "",
    area: "",
    smoothness: "",
    compactness: "",
    concavity: "",
    concave_points: "",
    symmetry: "",
    fractal_dimension: "",
  });
  const submitHandler = async (event) => {
    event.preventDefault();
    await props.predictionHandler(features);
  };

  const radiusHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, radius: e.target.value });
  };
  const textureHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, texture: e.target.value });
  };
  const perimeterHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, perimeter: e.target.value });
  };
  const areaHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, area: e.target.value });
  };
  const smoothnessHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, smoothness: e.target.value });
  };
  const compactnessHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, compactness: e.target.value });
  };
  const concavityHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, concavity: e.target.value });
  };
  const concave_pointsHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, concave_points: e.target.value });
  };
  const symmetryHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, symmetry: e.target.value });
  };
  const fractal_dimensionHandler = (e) => {
    e.preventDefault();
    setFeatures({ ...features, fractal_dimension: e.target.value });
  };

  return (
    <form onSubmit={submitHandler} className="login-form">
      <div className="form-container">
        <h2>Add data for prediction</h2>
        {props.error !== "" ? <div className="error">{props.error}</div> : ""}
        {props.success !== "" ? (
          <div className="success">{props.success}</div>
        ) : (
          ""
        )}
        <div className="form-group">
          <label htmlFor="radius">Radius:</label>
          <input
            type="text"
            name="radius"
            id="radius"
            value={features.radius}
            onChange={radiusHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="texture">Texture:</label>
          <input
            type="text"
            name="texture"
            id="texture"
            value={features.texture}
            onChange={textureHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="perimeter">Perimeter:</label>
          <input
            type="text"
            name="perimeter"
            id="perimeter"
            value={features.perimeter}
            onChange={perimeterHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="area">Area:</label>
          <input
            type="text"
            name="area"
            id="area"
            value={features.area}
            onChange={areaHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="smoothness">Smoothness:</label>
          <input
            type="text"
            name="smoothness"
            id="smoothness"
            value={features.smoothness}
            onChange={smoothnessHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="compactness">Compactness:</label>
          <input
            type="text"
            name="compactness"
            id="compactness"
            value={features.compactness}
            onChange={compactnessHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="concavity">Concavity:</label>
          <input
            type="text"
            name="concavity"
            id="concavity"
            value={features.concavity}
            onChange={concavityHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="concave_points">Concave_points:</label>
          <input
            type="text"
            name="concave_points"
            id="concave_points"
            value={features.concave_points}
            onChange={concave_pointsHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="symmetry">Symmetry:</label>
          <input
            type="text"
            name="symmetry"
            id="symmetry"
            value={features.symmetry}
            onChange={symmetryHandler}
          />
        </div>
        <div className="form-group">
          <label htmlFor="fractal_dimension">Fractal_dimension:</label>
          <input
            type="text"
            name="fractal_dimension"
            id="fractal_dimension"
            value={features.fractal_dimension}
            onChange={fractal_dimensionHandler}
          />
        </div>
        <input type="submit" value="SendPredictionData" />
      </div>
    </form>
  );
};

export default PredictionForm;
