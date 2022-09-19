import React from "react";
import NavBar from "./components/navbar";
import { Routes, Route, Link, Outlet } from "react-router-dom";
import { ROUTES } from "./routes/routes";
import YoutubePage from "./pages/youtube/youtubePage";
import LandingPage from "./pages/landing/landingPage";
import RegisterPage from "./pages/register/registerPage";
import LoginPage from "./pages/login/loginPage";
import { usePromiseTracker } from "react-promise-tracker";
import { RingLoader } from "react-spinners";


function Layout() {
  return (
    <div>
      <NavBar />
      <Outlet />
    </div>
  );
}

export default function App() {
  const { promiseInProgress } = usePromiseTracker();

  return (
    <>
      {
        promiseInProgress === true ?
          <>
            <div className="absolute inset-0 z-10">
              <RingLoader size={100} className="m-auto" />
            </div>
          </> : ''
      }
      <div className={promiseInProgress ? "blur-sm" : ""}>
        <Skeleton>
          <Routes>
            <Route path={ROUTES.REGISTER} element={<RegisterPage />} />
            <Route path={ROUTES.LOGIN} element={<LoginPage />} />
            <Route path={'/'} element={<Layout />}>
              <Route path={ROUTES.LANDING} element={<LandingPage />} />
              <Route path={ROUTES.PLAYLISTS} element={<YoutubePage />} />
            </Route>
            <Route path="*" element={<>ERROR no path found</>} />
          </Routes>
        </Skeleton>
      </div>
    </>
  );
}

interface ISkeletonProps {
  children: JSX.Element
}

function Skeleton(props: ISkeletonProps) {
  return <>
    {/* <div className="mt-5 p-4 max-w-6xl mx-auto bg-white space-x-4"> */}
    <div className="max-w-6xl mx-auto bg-white space-x-4">
      <div>
        {props.children}
      </div>
    </div>
  </>
}
