export { auth as middleware } from "@/auth";
export const config = {
  matcher: ["/session"],
  pages: {
    signin: "/api/auth/signin"
  }
};
