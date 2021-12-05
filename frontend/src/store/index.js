import { configureStore } from "@reduxjs/toolkit";
import authSliceReducer from "./auth";
import "font-awesome/css/font-awesome.min.css";

const store = configureStore({
  reducer: { auth: authSliceReducer },
});

export default store;
